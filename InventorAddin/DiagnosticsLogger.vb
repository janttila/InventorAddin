Imports System.IO

Namespace $projectname$
        
  
    Public Module DiagnosticsLogger

        Private ReadOnly LoggingOn As Boolean = False

        Private ReadOnly logPath As String = Path.Combine(Path.GetTempPath(), "Vaul2025Test_log.txt")

        Public Sub Log(msg As String)

            If LoggingOn Then

                Try
                    Dim line = DateTime.Now.ToString("s") & " - " & msg & Environment.NewLine
                    File.AppendAllText(logPath, line)
                Catch
                    ' Swallow any logging errors
                End Try

            End If

        End Sub



    End Module
End Namespace
