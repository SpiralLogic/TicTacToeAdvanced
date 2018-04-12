class Board extends React.Component {
    constructor(props) {
        super(props);
        this.updateGame = this.updateGame.bind(this);
        this.coordinatesClicked = this.coordinatesClicked.bind(this);
        this.state = {board: [], gameState: ''};
    }

    componentDidMount() {
        fetch('/api/game/', {method: 'get', credentials: "include"})
            .then(response => response.json())
            .then(data => this.updateGame(data))
            .catch(err => console.log(err));
    }

    updateGame(game) {
        this.setState({gameState: game.gameState});
        this.setState({board: game.board});
    }

    coordinatesClicked(x, y) {
        fetch(`/api/game/taketurn/${x}/${y}`, {method: 'get', credentials: "include"})
            .then(response => response.json())
            .then(data => this.updateGame(data))
            .catch(err => console.log(err));
    }

    render() {
        const board = this.state.board;
        const gameState = this.state.gameState;
        return (
            <div className="board"><p>{gameState}</p>
                {board && board.map((row, index) =>
                    <Row key={index} x={index + 1} coords={row} updateFunction={this.coordinatesClicked}/>
                )}
            </div>
        );
    }
}

//const game = "{\"board\":[[\".\",\".\",\".\"],[\".\",\".\",\".\"],[\".\",\".\",\".\"]],\"gameSate\":\"Player 1 enter a coord x,y to place your X or enter 'q' to give up\"}";
ReactDOM.render(
    <Board/>,
    document.getElementById('content')
);
