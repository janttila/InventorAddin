Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text.Json
Imports Inventor
Imports System.Reflection
Imports $projectname$.$projectname$

Namespace $projectname$
    <ProgIdAttribute("$projectname$AddInServer"),
    GuidAttribute("$guid1$")>
	Public Class $projectname$AddInServer
        Implements Inventor.ApplicationAddInServer

        Private WithEvents MuiEvents As UserInterfaceEvents

        Private _rbManager As RibbonButtonManager

             Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate
        g_inventorApplication = addInSiteObject.Application

        MuiEvents = g_inventorApplication.UserInterfaceManager.UserInterfaceEvents
        AddHandler MuiEvents.OnResetRibbonInterface, AddressOf MuiEvents_OnResetRibbonInterface

        _rbManager = New RibbonButtonManager(g_inventorApplication, AddressOf AddInClientID)

        ' Handler factories map a handler name (from JSON) to a factory that returns a RibbonExecuteHandler for that button.
        Dim handlerFactories As New Global.System.Collections.Generic.Dictionary(Of String, Func(Of ButtonConfig, RibbonExecuteHandler))(StringComparer.OrdinalIgnoreCase)

        '----------------------------------------------------------
        '******** Register built-in handler factories here ********

        handlerFactories.Add("ShowDisplay", AddressOf MakeShowDisplay)
        handlerFactories.Add("ShowInternal", AddressOf MakeShowInternal)

        '----------------------------------------------------------

        handlerFactories.Add("NoOp", AddressOf MakeNoOp)

        ' Load button configuration from ButtonCfg.json (only use JSON; do not register hardcoded buttons)
        Dim cfgPath As String = IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location) & "\ButtonCfg.json"
        If Global.System.IO.File.Exists(cfgPath) Then
            Try
                Dim json As String = Global.System.IO.File.ReadAllText(cfgPath)
                Dim cfg As ButtonConfig() = Nothing
                Dim jsonValid As Boolean = True
                Try
                    cfg = JsonSerializer.Deserialize(Of ButtonConfig())(json)
                    If cfg Is Nothing OrElse cfg.Length = 0 Then
                        jsonValid = False
                        MsgBox("ButtonCfg.json parsed but contains no button entries.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ButtonCfg.json")
                    End If
                Catch ex As Exception
                    jsonValid = False
                    MsgBox("Error parsing ButtonCfg.json: " & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ButtonCfg.json")
                End Try

                If jsonValid AndAlso cfg IsNot Nothing Then


                    For Each item In cfg
                        Dim smallImg As System.Drawing.Image = Nothing
                        Dim largeImg As System.Drawing.Image = Nothing
                        Try
                            If Not String.IsNullOrEmpty(item.SmallImage) Then
                                    Dim obj = GetResourceObject(item.SmallImage)
                                    If obj IsNot Nothing Then
                                    If TypeOf obj Is System.Drawing.Image Then
                                        smallImg = CType(obj, System.Drawing.Image)
                                    ElseIf TypeOf obj Is Byte() Then
                                        Using ms As New IO.MemoryStream(CType(obj, Byte()))
                                            smallImg = System.Drawing.Image.FromStream(ms)
                                        End Using
                                    End If
                                End If
                            End If
                            If Not String.IsNullOrEmpty(item.LargeImage) Then
                                    Dim obj2 = GetResourceObject(item.LargeImage)
                                    If obj2 IsNot Nothing Then
                                    If TypeOf obj2 Is System.Drawing.Image Then
                                        largeImg = CType(obj2, System.Drawing.Image)
                                    ElseIf TypeOf obj2 Is Byte() Then
                                        Using ms As New IO.MemoryStream(CType(obj2, Byte()))
                                            largeImg = System.Drawing.Image.FromStream(ms)
                                        End Using

                                    End If
                                End If
                            End If
                        Catch
                        End Try

                        ' Determine execute handler for this item (use default ShowDisplay when unspecified)
                        Dim execHandler As RibbonExecuteHandler = Nothing
                        Try
                            If Not String.IsNullOrEmpty(item.Handler) AndAlso handlerFactories.ContainsKey(item.Handler) Then
                                execHandler = handlerFactories(item.Handler).Invoke(item)
                            Else
                                execHandler = New RibbonExecuteHandler(Sub(ctx) MsgBox(item.DisplayName))
                            End If
                        Catch
                            execHandler = New RibbonExecuteHandler(Sub(ctx) MsgBox(item.DisplayName))
                        End Try

                        ' Support multiple TabId values separated by commas. Register button for each tab id.
                        If Not String.IsNullOrEmpty(item.TabId) Then
                            Dim tabIds = item.TabId.Split({","c}, StringSplitOptions.RemoveEmptyEntries)
                            If tabIds.Length > 1 Then
                                Dim idx As Integer = 1
                                For Each t In tabIds
                                    Dim tabTrim = t.Trim()
                                    If tabTrim.Length > 0 Then
                                        Dim uniqueInternalId = item.InternalId & "_" & idx.ToString()
                                        _rbManager.RegisterButton(item.RibbonName, tabTrim, item.PanelId, item.PanelName, item.DisplayName, uniqueInternalId, item.Tooltip, smallImg, largeImg, execHandler)
                                        idx += 1
                                    End If
                                Next
                            Else
                                Dim tabTrim = tabIds(0).Trim()
                                If tabTrim.Length > 0 Then
                                    _rbManager.RegisterButton(item.RibbonName, tabTrim, item.PanelId, item.PanelName, item.DisplayName, item.InternalId, item.Tooltip, smallImg, largeImg, execHandler)
                                End If
                            End If
                        Else
                            ' If no TabId specified, register with the provided InternalId (may not be added to UI)
                            _rbManager.RegisterButton(item.RibbonName, item.TabId, item.PanelId, item.PanelName, item.DisplayName, item.InternalId, item.Tooltip, smallImg, largeImg, execHandler)
                        End If
                    Next
                End If
            Catch
            End Try
        End If

        Try
            _rbManager.AddToUserInterface()
        Catch
        End Try
    End Sub



        Private Function GetResourceObject(resourceName As String) As Object
            Try
                Dim asm = Assembly.GetExecutingAssembly()
                Dim baseName = asm.GetName().Name & ".Resources"
                Dim rm As New Global.System.Resources.ResourceManager(baseName, asm)
                Return rm.GetObject(resourceName)
            Catch
                Return Nothing
            End Try
        End Function

        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate
            RemoveHandler MuiEvents.OnResetRibbonInterface, AddressOf MuiEvents_OnResetRibbonInterface
            MuiEvents = Nothing
            _rbManager = Nothing
            g_inventorApplication = Nothing

            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        End Sub

        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation
            Get
                Return Nothing
            End Get
        End Property

        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand
        End Sub

        Private Sub MuiEvents_OnResetRibbonInterface(Context As NameValueMap)
            If _rbManager IsNot Nothing Then
                _rbManager.ResetRibbonInterface()
            End If
        End Sub

        '-----------------------------------------------------------------------
        ' ******* Handler factory helpers  *************************************

        Private Function MakeShowDisplay(cfg As ButtonConfig) As RibbonExecuteHandler
            Return New RibbonExecuteHandler(Sub(ctx As NameValueMap)
                                                Try
                                                    MsgBox(cfg.DisplayName)
                                                Catch
                                                End Try
                                            End Sub)
        End Function

        Private Function MakeShowInternal(cfg As ButtonConfig) As RibbonExecuteHandler
            Return New RibbonExecuteHandler(Sub(ctx As NameValueMap)
                                                Try
                                                    MsgBox(cfg.InternalId)
                                                Catch
                                                End Try
                                            End Sub)
        End Function

        '-----------------------------------------------------------------------
        '-----------------------------------------------------------------------

        Private Function MakeNoOp(cfg As ButtonConfig) As RibbonExecuteHandler
            Return New RibbonExecuteHandler(Sub(ctx As NameValueMap)
                                                ' no op
                                            End Sub)
        End Function
    End Class

    ' Simple config shape for deserializing ButtonCfg.json
    Public Class ButtonConfig
        Public Property RibbonName As String
        Public Property TabId As String
        Public Property DisplayName As String
        Public Property InternalId As String
        Public Property Tooltip As String
        Public Property SmallImage As String
        Public Property LargeImage As String
        Public Property PanelId As String
        Public Property PanelName As String
        Public Property Handler As String
    End Class
End Namespace

' Globals
Public Module Globals
    Friend g_inventorApplication As Inventor.Application

    Public Function AddInClientID() As String
        Dim guid As String = ""
        Try
            Dim t As Type = GetType($projectname$AddInServer)
            Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
            Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
            guid = "{" + guidAttribute.Value.ToString() + "}"
        Catch
        End Try

        Return guid
    End Function
End Module
