Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

    Sub unhandledExceptionHandler(sender As Object, args As UnhandledExceptionEventArgs)
        Dim ex As Exception = DirectCast(args.ExceptionObject, Exception)
        Dim Result As New String("")
        Dim st As StackTrace = New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                Result += $"{IO.Path.GetFileName(sf.GetFileName)} ({sf.GetFileLineNumber()}){vbNewLine}"
            End If
        Next
        MessageBox.Show($"Exception: {ex.Message}
Thrown in: {ex.TargetSite.DeclaringType}.{ex.TargetSite.Name}

{Result}
Please contact P52Smith with this information

Unfortunately, we have to close now, sorry", "An error has occurred", MessageBoxButton.OK, MessageBoxImage.Error)
    End Sub

    Public Shared ReadOnly Property appVersion As String
        Get
            If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                Dim ourVersion = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                Return $"v{ourVersion.Major}.{ourVersion.Minor}.{ourVersion.Build}.{ourVersion.Revision}"
            Else
                Return "Development build"
            End If
        End Get
    End Property

End Class
