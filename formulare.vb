Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange({"Baccalauréat", "1ere année supérieur", "2eme année supérieur", "license", "master", "doctorat"})
        CheckedListBox1.Items.AddRange({"Arabe", "Francais", "Anglais", "Autre"})
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validation du formulaire
        Dim errorMessage As String = ""

        ' Validation du nom complet
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse Not TextBox1.Text.Contains(" ") Then
            errorMessage &= "Veuillez entrer un nom complet valide avec un espace entre le prénom et le nom." & vbCrLf
        End If

        ' Validation de la date de naissance
        If DateTimePicker1.Value.Date >= DateTime.Today OrElse DateTime.Today.Year - DateTimePicker1.Value.Year < 18 Then
            errorMessage &= "Veuillez entrer une date de naissance valide. L'utilisateur doit avoir au moins 18 ans." & vbCrLf
        End If

        ' Validation de l'adresse
        If String.IsNullOrWhiteSpace(RichTextBox1.Text) Then
            errorMessage &= "Veuillez entrer une adresse." & vbCrLf
        End If

        ' Validation du code postal
        If Not MaskedTextBox1.MaskCompleted Then
            errorMessage &= "Veuillez entrer un code postal valide."
        End If

        ' Validation des langues parlées
        If CheckedListBox1.CheckedItems.Count = -1 Then
            errorMessage &= "Veuillez sélectionner au moins une langue parlée."
        End If

        ' Validation du niveau d'éducation
        If ComboBox1.SelectedIndex = -1 Then
            errorMessage &= "Veuillez sélectionner un niveau d'éducation."
        End If

        ' Affichage des messages d'erreur s'il y en a
        If errorMessage <> "" Then
            MessageBox.Show(errorMessage, "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Formulaire validé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
