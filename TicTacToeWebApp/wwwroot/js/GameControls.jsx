class GameControls extends React.Component {
    constructor(props) {
        super(props);
        this.handleBoardLengthChange = this.handleBoardLengthChange.bind(this);
        this.state = {boardLength: 3};
    }

    handleBoardLengthChange(event) {
        this.setState({boardLength: event.target.value});
    }

    render() {
        const boardLength = this.state.boardLength;
        const {startHandler, forfeitHandler} = this.props;
        return (
            <div className="gameControls">
                <button onClick={() => startHandler(boardLength)}>New Game</button>
                <label>Board Length:<input onChange={this.handleBoardLengthChange} value={boardLength} type="number"
                                           step="1"
                                           min="0" max="10"/></label>
                <button onClick={() => forfeitHandler()}>Forfeit Game</button>
            </div>
        )
    }
}
