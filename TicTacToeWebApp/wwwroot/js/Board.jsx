class Board extends React.Component {
    componentDidUpdate() {
        this.updateDimensions();
    }

    componentDidMount() {
        window.addEventListener("resize", this.updateDimensions);
    }

    componentWillUnmount() {
        window.removeEventListener("resize", this.updateDimensions);
    }

    updateDimensions() {
        const coords = document.querySelectorAll(".coordinate");
        if (coords.length > 0) {
            const resizeTo = Math.min(coords[0].offsetHeight, coords[0].offsetWidth);
            coords.forEach((e) => e.style.fontSize = `${resizeTo}px`);
            console.log(resizeTo);
        }
    }

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