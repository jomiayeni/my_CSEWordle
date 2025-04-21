<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WordleWebApp.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Page</title>
    <style type="text/css">
        .letter-box {
            width: 30px;
            height: 30px;
            display: inline-block;
            text-align: center;
            line-height: 30px;
            margin: 2px;
            font-weight: bold;
            font-size: 18px;
            border-radius: 3px;
        }
        .correct-letter {
            background-color: green;
            color: white;
        }
        .correct-letter-wrong-spot {
            background-color: yellow;
            color: black;
        }
        .incorrect-letter {
            background-color: gray;
            color: white;
        }
        .unknown-letter {
            background-color: lightgray;
            color: black;
        }
        .guess-row {
            margin-bottom: 5px;
        }

        .keyboard { margin-top: 20px; }
        .keyboard-row { text-align: center; }
    
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to the member page</h1>

            <p>Here users will be able to play puzzles.</p>
            <p>
                <asp:Button ID="gameGeneratorBtn" runat="server" Text="Click here to play a game." OnClick="gameGeneratorBtn_Click" />
                <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
                <asp:Button ID="logoutBtn" runat="server" Text="Logout" PostBackUrl="~/Logout.aspx" />

            </p>
           
            <!-- maxlength 5 for wordle but may want this to be dynamic !-->
            <asp:TextBox ID="guessTextBox" runat="server" MaxLength="5"></asp:TextBox>


            <asp:Button ID="submitGuessBtn" runat="server" Text="Submit Guess" OnClick="submitGuessBtn_Click" />
            <asp:Button ID="hintBtn" runat="server" Text="Get a Hint" OnClick="hintBtn_Click" />

            <br /><br />

            <asp:Label ID="testLbl" runat="server" />
           
            <asp:Label ID="resultLbl" runat="server" Text=""></asp:Label>

            <asp:Panel ID="guessesPanel" runat="server"></asp:Panel>
            
            <asp:Literal ID="keyboardLiteral" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
