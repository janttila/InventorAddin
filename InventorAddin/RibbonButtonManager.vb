Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports Inventor

Namespace $projectname$

   
    Public Delegate Sub RibbonExecuteHandler(Context As NameValueMap)

    ''' <summary>
    ''' Manages creation of ButtonDefinitions and adding them to ribbons/tabs/panels.
    ''' Use RegisterButton to declare a button and AddToUserInterface to add them to the Inventor UI.
    ''' </summary>
    Public Class RibbonButtonManager
        Private ReadOnly _app As Inventor.Application
        Private ReadOnly _addInClientIdFunc As Func(Of String)

        Private Class ButtonEntry
            Public Property RibbonName As String
            Public Property TabId As String
            Public Property PanelId As String
            Public Property PanelName As String
            Public Property DisplayName As String
            Public Property InternalId As String
            Public Property Tooltip As String
            Public Property SmallImage As System.Drawing.Image
            Public Property LargeImage As System.Drawing.Image
            Public Property ButtonDef As ButtonDefinition
            Public Property ExecuteHandler As RibbonExecuteHandler
        End Class

        Private ReadOnly _buttons As New List(Of ButtonEntry)()

        Public Sub New(app As Inventor.Application, addInClientIdFunc As Func(Of String))
            _app = app
            _addInClientIdFunc = addInClientIdFunc
        End Sub

        ''' <summary>
        ''' Register a button to be created and added to the UI.
        ''' </summary>
        Public Sub RegisterButton(ribbonName As String, tabId As String, panelId As String, panelName As String, displayName As String, internalId As String, tooltip As String, smallImage As System.Drawing.Image, largeImage As System.Drawing.Image, Optional executeHandler As RibbonExecuteHandler = Nothing)
            Dim be As New ButtonEntry With {
                .RibbonName = ribbonName,
                .TabId = tabId,
                .PanelId = panelId,
                .PanelName = panelName,
                .DisplayName = displayName,
                .InternalId = internalId,
                .Tooltip = tooltip,
                .SmallImage = smallImage,
                .LargeImage = largeImage,
                .ExecuteHandler = executeHandler
            }
            _buttons.Add(be)
        End Sub

        ''' <summary>
        ''' Ensure ButtonDefinition objects exist for registered buttons.
        ''' Attaches a click handler that either calls the supplied handler or shows a message box with the button name.
        ''' </summary>
        Public Sub CreateDefinitions()
            For Each be In _buttons
                If be.ButtonDef Is Nothing Then
                    be.ButtonDef = CreateButtonDefinition(be.DisplayName, be.InternalId, be.Tooltip, CType(be.SmallImage, System.Drawing.Image), CType(be.LargeImage, System.Drawing.Image))

                    If be.ButtonDef IsNot Nothing Then
                        ' Attach an execute handler that captures either the supplied handler or a default behavior.
                        Try
                            If be.ExecuteHandler IsNot Nothing Then
                                AddHandler be.ButtonDef.OnExecute, Sub(Context As NameValueMap)
                                                                       Try
                                                                           Dim h = be.ExecuteHandler
                                                                           If h IsNot Nothing Then h.Invoke(Context)
                                                                       Catch
                                                                       End Try
                                                                   End Sub
                            Else
                                AddHandler be.ButtonDef.OnExecute, Sub(Context As NameValueMap)
                                                                       Try
                                                                           MsgBox(be.DisplayName)
                                                                       Catch
                                                                       End Try
                                                                   End Sub
                            End If
                        Catch
                        End Try
                    End If
                End If
            Next
        End Sub

        ''' <summary>
        ''' Add registered buttons to their specified ribbons/tabs/panels. Safe to call after ribbon reset.
        ''' </summary>
        Public Sub AddToUserInterface()
            CreateDefinitions()

            For Each be In _buttons
                Try
                    Dim ribbon As Ribbon = _app.UserInterfaceManager.Ribbons.Item(be.RibbonName)
                    Dim tab As RibbonTab = ribbon.RibbonTabs.Item(be.TabId)

                    Dim panel As RibbonPanel = Nothing
                    Try
                        panel = tab.RibbonPanels.Item(be.PanelId)
                    Catch ex As Exception
                        ' Panel doesn't exist - create it
                        panel = tab.RibbonPanels.Add(be.PanelId, be.PanelName, _addInClientIdFunc())
                    End Try

                    If be.ButtonDef IsNot Nothing Then
                        Try
                            ' Add button to the panel. If the same control already exists this may throw - ignore duplicates.
                            panel.CommandControls.AddButton(be.ButtonDef, True)
                        Catch
                        End Try
                    End If
                Catch
                    ' Could not find ribbon/tab - ignore (some Inventor ribbons may not be present in all environments)
                End Try
            Next
        End Sub

        ''' <summary>
        ''' Called when the ribbon interface is reset. Rebuilds the UI.
        ''' </summary>
        Public Sub ResetRibbonInterface()
            AddToUserInterface()
        End Sub

        ' Inlined Utilities.CreateButtonDefinition and PictureDispConverter
        Private Function CreateButtonDefinition(DisplayName As String,
                                           InternalName As String,
                                           Optional ToolTip As String = "",
                                           Optional SIcon As System.Drawing.Image = Nothing,
                                           Optional BIcon As System.Drawing.Image = Nothing) As Inventor.ButtonDefinition
            ' Check to see if a command already exists is the specified internal name.
            Dim testDef As Inventor.ButtonDefinition = Nothing
            Try
                testDef = g_inventorApplication.CommandManager.ControlDefinitions.Item(InternalName)
            Catch ex As Exception
            End Try

            If testDef IsNot Nothing Then
                MsgBox("Error when loading the add-in: a command already exists with the same internal name. Change the internal name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Inventor Add-In")
                Return Nothing
            End If

            Try
                Dim iPicDisp16x16 As stdole.IPictureDisp = Nothing
                Dim iPicDisp32x32 As stdole.IPictureDisp = Nothing

                If SIcon IsNot Nothing Then
                    Try
                        Dim bmp16 As System.Drawing.Bitmap = New System.Drawing.Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                        Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp16)
                            g.Clear(System.Drawing.Color.Transparent)
                            g.DrawImage(SIcon, 0, 0, 16, 16)
                        End Using
                        ' Remove alpha channel by copying to a 24bpp bitmap to avoid GetHbitmap alpha issues
                        Dim bmp16NoAlpha As New System.Drawing.Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                        Using g2 As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp16NoAlpha)
                            g2.Clear(System.Drawing.Color.White)
                            g2.DrawImage(bmp16, 0, 0, 16, 16)
                        End Using
                        iPicDisp16x16 = PictureDispConverter.ToIPictureDisp(bmp16NoAlpha)
                    Catch
                    End Try
                End If
                If BIcon IsNot Nothing Then
                    Try
                        Dim bmp32 As System.Drawing.Bitmap = New System.Drawing.Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                        Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp32)
                            g.Clear(System.Drawing.Color.Transparent)
                            g.DrawImage(BIcon, 0, 0, 32, 32)
                        End Using
                        Dim bmp32NoAlpha As New System.Drawing.Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                        Using g2 As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp32NoAlpha)
                            g2.Clear(System.Drawing.Color.White)
                            g2.DrawImage(bmp32, 0, 0, 32, 32)
                        End Using
                        iPicDisp32x32 = PictureDispConverter.ToIPictureDisp(bmp32NoAlpha)
                    Catch
                    End Try
                End If

                ' Get the ControlDefinitions collection.
                Dim controlDefs As Inventor.ControlDefinitions = g_inventorApplication.CommandManager.ControlDefinitions

                ' Create the command defintion.
                Dim btnDef As Inventor.ButtonDefinition = controlDefs.AddButtonDefinition(DisplayName,
                                                                                      InternalName,
                                                                                      Inventor.CommandTypesEnum.kShapeEditCmdType,
                                                                                      AddInClientID,
                                                                                      "",
                                                                                      ToolTip,
                                                                                      iPicDisp16x16,
                                                                                      iPicDisp32x32)
                Return btnDef
            Catch ex As Exception
                Return Nothing
            End Try
        End Function




        Private NotInheritable Class PICTDESC
            Private Sub New()
            End Sub

            Public Const PICTYPE_BITMAP As Short = 1
            Public Const PICTYPE_ICON As Short = 3

            <StructLayout(LayoutKind.Sequential)>
            Public Class Icon
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
                Friend picType As Integer = PICTDESC.PICTYPE_ICON
                Friend hicon As IntPtr = IntPtr.Zero
                Friend unused1 As Integer
                Friend unused2 As Integer

                Friend Sub New(ByVal icon As System.Drawing.Icon)
                    If Not OperatingSystem.IsWindows() OrElse Not OperatingSystem.IsWindowsVersionAtLeast(6, 1) Then
                        Throw New PlatformNotSupportedException("Icon.ToBitmap().GetHicon() requires Windows 6.1 or later.")
                    End If
                    Me.hicon = icon.ToBitmap().GetHicon()
                End Sub
            End Class

            <StructLayout(LayoutKind.Sequential)>
            Public Class Bitmap
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Bitmap))
                Friend picType As Integer = PICTDESC.PICTYPE_BITMAP
                Friend hbitmap As IntPtr = IntPtr.Zero
                Friend hpal As IntPtr = IntPtr.Zero
                Friend unused As Integer

                Friend Sub New(ByVal bitmap As System.Drawing.Bitmap)
                    If Not OperatingSystem.IsWindows() OrElse Not OperatingSystem.IsWindowsVersionAtLeast(6, 1) Then
                        Throw New PlatformNotSupportedException("Bitmap.GetHbitmap() requires Windows 6.1 or later.")
                    End If
                    Me.hbitmap = bitmap.GetHbitmap()
                End Sub
            End Class
        End Class




    End Class


    Public NotInheritable Class PictureDispConverter



        <DllImport("OleAut32.dll", EntryPoint:="OleCreatePictureIndirect", ExactSpelling:=True, PreserveSig:=False)>
        Private Shared Function OleCreatePictureIndirect(
                    ByVal picdescPtr As IntPtr,
                    ByRef iid As Guid,
                    <MarshalAs(UnmanagedType.Bool)> ByVal fOwn As Boolean) As stdole.IPictureDisp
        End Function

        Shared iPictureDispGuid As Guid = GetType(stdole.IPictureDisp).GUID

        Private NotInheritable Class PICTDESC

            Private Sub New()
            End Sub

            Public Const PICTYPE_UNINITIALIZED As Short = -1
            Public Const PICTYPE_NONE As Short = 0
            Public Const PICTYPE_BITMAP As Short = 1
            Public Const PICTYPE_METAFILE As Short = 2
            Public Const PICTYPE_ICON As Short = 3
            Public Const PICTYPE_ENHMETAFILE As Short = 4

            <StructLayout(LayoutKind.Sequential)>
            Public Class Icon
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
                Friend picType As Integer = PICTDESC.PICTYPE_ICON
                Friend hicon As IntPtr = IntPtr.Zero
                Friend unused1 As Integer
                Friend unused2 As Integer

                Friend Sub New(ByVal icon As System.Drawing.Icon)
                    Me.hicon = icon.ToBitmap().GetHicon()
                End Sub

            End Class

            <StructLayout(LayoutKind.Sequential)>
            Public Class Bitmap
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Bitmap))
                Friend picType As Integer = PICTDESC.PICTYPE_BITMAP
                Friend hbitmap As IntPtr = IntPtr.Zero
                Friend hpal As IntPtr = IntPtr.Zero
                Friend unused As Integer

                Friend Sub New(ByVal bitmap As System.Drawing.Bitmap)
                    Me.hbitmap = bitmap.GetHbitmap()
                End Sub
            End Class
        End Class

        Public Shared Function ToIPictureDisp(ByVal icon As System.Drawing.Icon) As stdole.IPictureDisp
            Dim pictIcon As New PICTDESC.Icon(icon)
            Dim size As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
            Dim ptr As IntPtr = Marshal.AllocHGlobal(size)
            Try
                Marshal.StructureToPtr(pictIcon, ptr, False)
                Return OleCreatePictureIndirect(ptr, iPictureDispGuid, True)
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Function

        Public Shared Function ToIPictureDisp(ByVal bmp As System.Drawing.Bitmap) As stdole.IPictureDisp
            Dim pictBmp As New PICTDESC.Bitmap(bmp)
            Dim size As Integer = Marshal.SizeOf(GetType(PICTDESC.Bitmap))
            Dim ptr As IntPtr = Marshal.AllocHGlobal(size)
            Try
                Marshal.StructureToPtr(pictBmp, ptr, False)
                Return OleCreatePictureIndirect(ptr, iPictureDispGuid, True)
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Function
    End Class

End Namespace