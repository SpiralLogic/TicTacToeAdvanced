class Game extends React.Component {
    constructor(props) {
        super(props);
        this.start = this.start.bind(this);
        this.forfeit = this.forfeit.bind(this);
        this.takeTurn = this.takeTurn.bind(this);
        this.makeRequest = this.makeRequest.bind(this);
        this.state = {gameState: '', player1: '', player2: '', turnStatus: "Go!", board: []};
    }

    componentDidMount() {
        this.start(3);
    }

    takeTurn(x, y) {
        this.makeRequest(`/api/game/taketurn/${x}/${y}`, (gameJson) => this.setState(gameJson), 'put');
    }

    start(boardLength) {
        this.makeRequest(`/api/game/${boardLength}`, (gameJson) => this.setState(gameJson), 'post');
    }

    forfeit() {
        this.makeRequest('/api/game/forfeit', (gameJson) => this.setState(gameJson), 'put');
    }

    makeRequest(url, responseCallback, method = 'get') {
        fetch(url, {
            method: method, credentials: "include",
            body: JSON.stringify(this.currentBoardState()),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
            .then(response => response.json())
            .then(json => responseCallback(json))
            .catch(err => console.log(err));
    }

    currentBoardState() {
        return {board: this.state.board, player1: this.state.player1, player2: this.state.player2};
    }

    render() {
        const {board, player1, player2, gameState, turnStatus} = this.state;
        return (
            <div className="game"><p>{gameState}</p>
                <Board board={board} player1={player1} player2={player2} turnTakenHandler={this.takeTurn}/>
                <p>{turnStatus}</p>
                <GameControls startHandler={this.start} forfeitHandler={this.forfeit}/>
            </div>
        );
    }
}

ReactDOM.render(
    <Game/>,
    document.getElementById('content')
);
