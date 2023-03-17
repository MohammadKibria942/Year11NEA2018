Module Module1
    Dim Decknum As Integer
    Dim Exercise(29) As Integer
    Dim Intelligence(29) As Integer
    Dim Drool(29) As Integer
    Dim Friendliness(29) As Integer
    Dim Dogs(29)
    Dim CPUpile As Integer
    Dim Playerpile As Integer
    Dim ShuffleIndex As Int32 = 1000
    Dim N As Int32 = 29
    Dim ShuffleArr(n), i, j, k, l As Int32
    Dim Turnstaken As Integer
    Sub Main()
        MainMenu()
    End Sub
    Sub MainMenu()
        Dim Choice As Integer
        Console.WriteLine("Welcome To Celebrity Dogs Game")
        Console.WriteLine("1. Playgame")
        Console.WriteLine("2. Quit")
        Console.Write("Enter A Number For What You Want To Do: ")
        Choice = Console.ReadLine()
        Console.Clear()
        If Choice = 1 Then
            GameSettings()
        ElseIf Choice = 2 Then
            End
        Else
            Console.WriteLine("Error That Is Not A Function")
            System.Threading.Thread.Sleep(3000)
            MainMenu()
        End If
        Console.ReadLine()
    End Sub
    Sub GameSettings()
        Console.Write("Input Number Of Cards For The Deck: ")
        Decknum = Console.ReadLine()
        If Decknum < 4 Then
            Console.WriteLine("Number Has To Be Greater Than 4")
            Console.WriteLine("")
            MainMenu()
        ElseIf Decknum > 30 Then
            Console.WriteLine("Number Has To Be 30 Or Less Than 30")
            Console.WriteLine("")
            MainMenu()
        ElseIf Decknum Mod 2 Then
            Console.WriteLine("Number Has To Be Even")
            Console.WriteLine("")
            MainMenu()
        End If
        CPUpile = Decknum / 2
        Playerpile = CPUpile
        cards()
    End Sub
    Sub Cards()
        Dim I As Integer
        For E = 0 To 29
            Exercise(E) = CInt(Math.Floor(9 * Rnd())) + 1
            Intelligence(E) = CInt(Math.Floor(99 * Rnd())) + 1
            Friendliness(E) = CInt(Math.Floor(9 * Rnd())) + 1
            Drool(E) = CInt(Math.Floor(9 * Rnd())) + 1
        Next
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\lolbo\Documents\dogs.txt.txt")
        Dim stringReader As String
        For I = 0 To 29
            stringReader = fileReader.ReadLine()
            Dogs(I) = stringReader
        Next
        Game()
    End Sub
    Sub Game()
        Console.Clear()
        If CPUpile = 0 Then
            EndGameScores()
        ElseIf Playerpile = 0 Then
            EndGameScores()
        End If
        Turnstaken = Turnstaken + 1
        For Q = 0 To N
            ShuffleArr(Q) = Q
        Next
        Dim RndNum As Random = New Random()
        For Q = 0 To ShuffleIndex
            k = RndNum.Next(0, N)
            l = RndNum.Next(0, N)
            j = ShuffleArr(k)
            ShuffleArr(k) = ShuffleArr(l)
            ShuffleArr(l) = j
        Next
        Dim Choice As Integer
        Console.WriteLine("Score: Player:" & " " & Playerpile & " " & "Cpu:" & " " & CPUpile)
        Console.WriteLine("")
        Console.WriteLine("Your Dog")
        Console.WriteLine("Name            " & Dogs(ShuffleArr(l)))
        Console.WriteLine("1.Exercise        " & Exercise(ShuffleArr(l)) & "/10")
        Console.WriteLine("2.Intelligence    " & Intelligence(ShuffleArr(l)) & "/100")
        Console.WriteLine("3.Friendliness    " & Friendliness(ShuffleArr(l)) & "/10")
        Console.WriteLine("4.Drool           " & Drool(ShuffleArr(l)) & "/10")
        Console.Write("Enter The Category Number: ")
        Choice = Console.ReadLine()
        If Choice = 1 Then
            ChoiceExercise()
        ElseIf Choice = 2 Then
            ChoiceIntelligence()
        ElseIf Choice = 3 Then
            ChoiceFriendliness()
        ElseIf Choice = 4 Then
            ChoiceDrool()
        Else
            Console.WriteLine("That Is Not A Category Please Start Again")
            GameSettings()
        End If
    End Sub
    Sub ScoreCounter()
        Dim CPUChoice As Integer
        If CPUpile = 0 Then
            EndGameScores()
        ElseIf Playerpile = 0 Then
            EndGameScores()
        End If
        Console.Clear()
        Turnstaken = Turnstaken + 1
        Console.WriteLine("Score: Player:" & " " & Playerpile & " " & "Cpu:" & " " & CPUpile)
        Console.WriteLine("Your Dog")
        Console.WriteLine("")
        Console.WriteLine("Name            " & Dogs(ShuffleArr(l)))
        Console.WriteLine("Exercise        " & Exercise(ShuffleArr(l)) & "/10")
        Console.WriteLine("Intelligence    " & Intelligence(ShuffleArr(l)) & "/100")
        Console.WriteLine("Friendliness    " & Friendliness(ShuffleArr(l)) & "/10")
        Console.WriteLine("Drool           " & Drool(ShuffleArr(l)) & "/10")
        Console.WriteLine("Computer Is Choosing A Category")
        System.Threading.Thread.Sleep(4500)
        CPUChoice = CInt(Math.Floor(3 * Rnd())) + 1
        If CPUChoice = 1 Then
            Console.WriteLine("Computer Has Chosen Exercise")
            ChoiceExercise()
        ElseIf CPUChoice = 2 Then
            Console.WriteLine("Computer Has Chosen Friendliness")
            ChoiceIntelligence()
        ElseIf CPUChoice = 3 Then
            Console.WriteLine("Computer Has Chosen Intelligence")
            ChoiceFriendliness()
        ElseIf CPUChoice = 4 Then
            Console.WriteLine("Computer Has Chosen Drool")
            ChoiceDrool()
        End If
    End Sub
    Sub ChoiceExercise()
        If Exercise(ShuffleArr(l)) > Exercise(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Exercise        " & Exercise(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Win!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile + 1
            CPUpile = CPUpile - 1
            System.Threading.Thread.Sleep(4500)
            Game()
        ElseIf Exercise(ShuffleArr(l)) < Exercise(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Exercise        " & Exercise(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Lose!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile - 1
            CPUpile = CPUpile + 1
            System.Threading.Thread.Sleep(4500)
            ScoreCounter()
        ElseIf Exercise(ShuffleArr(l)) = Exercise(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Exercise        " & Exercise(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Drew!")
            Console.WriteLine("Next Round Is Loading...")
            System.Threading.Thread.Sleep(4500)
            Game()
        End If
    End Sub
    Sub ChoiceIntelligence()
        If Intelligence(ShuffleArr(l)) > Intelligence(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Intelligence    " & Intelligence(ShuffleArr(k)) & "/100")
            Console.WriteLine("You Win!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile + 1
            CPUpile = CPUpile - 1
            System.Threading.Thread.Sleep(4500)
            Game()
        ElseIf Intelligence(ShuffleArr(l)) < Intelligence(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Intelligence    " & Intelligence(ShuffleArr(k)) & "/100")
            Console.WriteLine("You Lose!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile - 1
            CPUpile = CPUpile + 1
            System.Threading.Thread.Sleep(4500)
            ScoreCounter()
        ElseIf Intelligence(ShuffleArr(l)) = Intelligence(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Intelligence    " & Intelligence(ShuffleArr(k)) & "/100")
            Console.WriteLine("You Drew!")
            Console.WriteLine("Next Round Is Loading...")
            System.Threading.Thread.Sleep(4500)
            Game()
        End If
    End Sub
    Sub ChoiceFriendliness()
        If Friendliness(ShuffleArr(l)) > Friendliness(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Friendliness    " & Friendliness(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Win!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile + 1
            CPUpile = CPUpile - 1
            System.Threading.Thread.Sleep(4500)
            Game()
        ElseIf Friendliness(ShuffleArr(l)) < Friendliness(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Friendliness    " & Friendliness(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Lose!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile - 1
            CPUpile = CPUpile + 1
            System.Threading.Thread.Sleep(4500)
            ScoreCounter()
        ElseIf Friendliness(ShuffleArr(l)) = Friendliness(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Friendliness    " & Friendliness(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Drew!")
            Console.WriteLine("Next Round Is Loading...")
            System.Threading.Thread.Sleep(4500)
            Game()
        End If
    End Sub
    Sub ChoiceDrool()
        If Drool(ShuffleArr(l)) > Drool(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Drool           " & Drool(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Lose!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile - 1
            CPUpile = CPUpile + 1
            System.Threading.Thread.Sleep(4500)
            ScoreCounter()
        ElseIf Drool(ShuffleArr(l)) < Drool(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Drool           " & Drool(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Win!")
            Console.WriteLine("Next Round Is Loading...")
            Playerpile = Playerpile + 1
            CPUpile = CPUpile - 1
            System.Threading.Thread.Sleep(4500)
            Game()
        ElseIf Drool(ShuffleArr(l)) = Drool(ShuffleArr(k)) Then
            Console.WriteLine("")
            Console.WriteLine("CPU Dog")
            Console.WriteLine("Name            " & Dogs(ShuffleArr(k)))
            Console.WriteLine("Drool           " & Drool(ShuffleArr(k)) & "/10")
            Console.WriteLine("You Drew!")
            Console.WriteLine("Next Round Is Loading...")
            System.Threading.Thread.Sleep(4500)
            Game()
        End If
    End Sub
    Sub EndGameScores()
        Dim Choice2 As String
        Console.Clear()
        If Playerpile > CPUpile Then
            Console.WriteLine("Congratulations, You Have Won The Celebrity Dogs Game")
            Console.WriteLine("Your Score Is: " & Playerpile)
            Console.WriteLine("Your Opponents Score Is: " & CPUpile)
            Console.WriteLine("Turns Taken: " & turnstaken)
        ElseIf Playerpile < CPUpile Then
            Console.WriteLine("Better Luck Next Time, You Have Lost The Celebrity Dogs Game")
            Console.WriteLine("Your Score Is: " & Playerpile)
            Console.WriteLine("Your Opponents Score Is: " & CPUpile)
            Console.WriteLine("Turns Taken: " & turnstaken)
        End If
        Console.WriteLine("Would You Like To Play Again? ")
        Console.Write("Enter Either Yes Or No: ")
        Choice2 = Console.ReadLine()
        If Choice2 = (LCase("yes")) Then
            GameSettings()
        ElseIf Choice2 = (LCase("no")) Then
            End
        Else
            Console.WriteLine("That is not an option")
            Console.WriteLine("Goodbye")
            System.Threading.Thread.Sleep(3000)
            End
        End If
    End Sub
End Module

