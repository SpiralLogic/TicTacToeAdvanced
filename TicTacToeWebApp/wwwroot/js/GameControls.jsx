class GameControls extends React.Component {
    constructor(props) {
        super(props);
        this.handleBoardLengthChange = this.handleBoardLengthChange.bind(this);
        this.handlePlayer1SymbolChange = this.handlePlayer1SymbolChange.bind(this);
        this.handlePlayer2SymbolChange = this.handlePlayer2SymbolChange.bind(this);
        this.handlePlayer1SymbolOnBlur = this.handlePlayer1SymbolOnBlur.bind(this);
        this.handlePlayer2SymbolOnBlur = this.handlePlayer2SymbolOnBlur.bind(this);
        this.state = {boardLength: 3, player1: 'X', player2: 'O'};
    }

    handleBoardLengthChange(event) {
        this.setState({boardLength: event.target.value});
    }

    handlePlayer1SymbolChange(event) {
        const newValue = event.target.value;
        if (newValue.length <= 1) {
            this.setState({player1: event.target.value});
        }
    }

    handlePlayer2SymbolChange(event) {
        const newValue = event.target.value;
        if (newValue.length <= 1) {
            this.setState({player2: event.target.value});
        }
    }

    handlePlayer1SymbolOnBlur(event) {
        const newValue = event.target.value;
        const oldValue = this.state.player1;
        if (newValue.length === 1) {
            this.setState({player1: event.target.value});
        } else {
            this.setState({player1: oldValue});
        }
    }

    handlePlayer2SymbolOnBlur(event) {
        const newValue = event.target.value;
        const oldValue = this.state.player2;
        if (newValue.length === 1) {
            this.setState({player2: event.target.value});
        } else {
            this.setState({player2: oldValue});
        }
    }


    render() {
        const boardLength = this.state.boardLength;
        const player1 = this.state.player1;
        const player2 = this.state.player2;
        const {startHandler, forfeitHandler} = this.props;
        return (
            <div className="game-controls">
                <button onClick={() => forfeitHandler()}>Forfeit Game</button>
                <label>Board Length:<input onChange={this.handleBoardLengthChange} value={boardLength} type="number"
                                           step="1"
                                           min="0" max="10"/></label>
                <label>Player 1 Symbol:<input onChange={this.handlePlayer1SymbolChange}
                                              onBlur={this.handlePlayer1SymbolOnBlur}
                                              value={player1} type="text"
                                              pattern=".{1,1}" required title="1 character required"/></label>
                <label>Player 2 Symbol:<input onChange={this.handlePlayer2SymbolChange}
                                              onBlur={this.handlePlayer2SymbolOnBlur}
                                              value={player2} type="text"
                                              pattern=".{1,1}" required title="1 character required"/></label>
                <button onClick={() => startHandler(boardLength, player1, player2)}>New Game</button>
            </div>
        )
    }
}
