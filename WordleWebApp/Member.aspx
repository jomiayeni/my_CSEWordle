<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WordleWebApp.Member" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wordle Web App - Member</title>
    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background: #f7f7f7;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .container {
            background: #fff;
            padding: 20px 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            width: 100%;
            max-width: 500px;
        }
        h1 {
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
        }
        .actions {
            text-align: center;
            margin-bottom: 15px;
        }
        .actions .btn {
            margin: 0 5px;
            padding: 8px 16px;
            background: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .guess-input {
            text-align: center;
            margin-bottom: 20px;
        }
        .guess-input input[type="text"] {
            width: 60%;
            padding: 8px;
            font-size: 16px;
            box-sizing: border-box;
            margin-right: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .guess-input .btn {
            padding: 8px 16px;
        }
        .result {
            text-align: center;
            margin-bottom: 15px;
            font-weight: bold;
            height: 24px;
        }
        .guesses-panel {
            text-align: center;
            margin-bottom: 20px;
        }
        .guess-row {
            margin-bottom: 5px;
        }
        .letter-box {
            width: 32px;
            height: 32px;
            display: inline-block;
            text-align: center;
            line-height: 32px;
            margin: 2px;
            font-weight: bold;
            border-radius: 4px;
        }
        .correct-letter { background-color: #28a745; color: #fff; }
        .correct-letter-wrong-spot { background-color: #ffc107; color: #000; }
        .incorrect-letter { background-color: #6c757d; color: #fff; }
        .unknown-letter { background-color: #e9ecef; color: #000; }
        .keyboard {
            text-align: center;
        }
        .keyboard-row {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <h1>Wordle Game</h1>
        <div class="actions">
            <asp:Button ID="gameGeneratorBtn" runat="server" Text="New Game" OnClick="gameGeneratorBtn_Click" CssClass="btn" />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" CssClass="btn" />
             <asp:Button ID="logoutBtn" runat="server" Text="Logout" PostBackUrl="~/Logout.aspx" />
        </div>
        <div class="guess-input">
            <asp:TextBox ID="guessTextBox" runat="server" MaxLength="5" CssClass="form-control" placeholder="Enter guess"></asp:TextBox>
            <asp:Button ID="submitGuessBtn" runat="server" Text="Submit" OnClick="submitGuessBtn_Click" CssClass="btn" />
            <asp:Button ID="hintBtn" runat="server" Text="Get a Hint" OnClick="hintBtn_Click" />
            <asp:Label ID="testLbl" runat="server" />
        </div>
          
        <div class="result">
            <asp:Label ID="resultLbl" runat="server" Text="" />
        </div>
        <div class="guesses-panel">
            <asp:Panel ID="guessesPanel" runat="server" CssClass="guesses-panel" />
        </div>
        <div class="keyboard">
            <asp:Literal ID="keyboardLiteral" runat="server" />
        </div>
    </form>
</body>
</html>
