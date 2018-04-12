class Board extends React.Component {
    constructor(props) {
        super(props);
        this.state = {fontSize: `1px`};
        this.updateDimensions = this.updateDimensions.bind(this);
    }

    componentDidMount() {
        window.addEventListener("resize", this.updateDimensions);
    }

    componentWillUnmount() {
        window.removeEventListener("resize", this.updateDimensions);
    }

    componentDidUpdate() {
        this.updateDimensions();
    }

    updateDimensions() {
        const coord = document.querySelector(".coordinate");
        if (coord !== null) {
            const resizeTo = `${Math.min(coord.offsetHeight, coord.offsetWidth)}px`;
            if (resizeTo !== this.state.fontSize) {
                console.log(resizeTo);
                this.setState({fontSize: resizeTo});
            }
        }
    }

    render() {
        const game = this.props.game;
        const board = game.board;
        const updateFunction = this.props.updateFunction;
        return (
            <div style={{fontSize: this.state.fontSize}} className="board">
                {board && board.map((row, index) =>
                    <Row key={index} x={index + 1} rowEntities={row} updateFunction={updateFunction} game={game}/>
                )}
            </div>
        );
    }
}