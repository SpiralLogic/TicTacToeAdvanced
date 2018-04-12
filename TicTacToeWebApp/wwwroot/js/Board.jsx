class Board extends React.Component {
    render() {
        const game = this.props.game;
        const board = game.board;
        const updateFunction = this.props.updateFunction;
        return (
            <div className="board">
                {board && board.map((row, index) =>
                    <Row key={index} x={index + 1} rowEntities={row} updateFunction={updateFunction} game={game}/>
                )}
                </div>
        );
    }
}