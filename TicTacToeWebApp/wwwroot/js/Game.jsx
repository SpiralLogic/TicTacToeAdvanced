class Game extends React.Component {
    constructor(props) {
        super(props);
        this.start = this.start.bind(this);
        this.forfeit = this.forfeit.bind(this);
        this.takeTurn = this.takeTurn.bind(this);
        this.makeRequest = this.makeRequest.bind(this);
        this.state = {board: [], gameState: '', player1: '', player2: ''};
    }

    componentDidMount() {
        this.start();
    }

    start() {
        this.makeRequest('/api/game', 'post');
    }

    forfeit() {
        this.makeRequest('/api/game/forfeit', 'put');
    }

    takeTurn(x, y) {
        this.makeRequest(`/api/game/taketurn/${x}/${y}`, 'put');
    }

    makeRequest(url, method = 'get') {
        fetch(url, {method: method, credentials: "include"})
            .then(response => response.json())
            .then(data => this.setState(data))
            .catch(err => console.log(err));
    }

    render() {
        const gameState = this.state.gameState;
        const turnStatus = this.state.turnStatus;
        const game = this.state;
        return (
            <div className="game"><p>{gameState}</p>
                <Board game={game} updateFunction={this.takeTurn}/>
                <p>{turnStatus}</p>
                <button onClick={this.start}>New Game</button>
                <button onClick={this.forfeit}>Forfeit Game</button>
            </div>
        );
    }
}

ReactDOM.render(
    <Game/>,
    document.getElementById('content')
);
