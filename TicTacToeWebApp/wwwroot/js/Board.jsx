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
                this.setState({fontSize: resizeTo});
            }
        }
    }

    render() {
        const {board, player1, player2, turnTakenHandler} = this.props;
        return (
            <div style={{fontSize: this.state.fontSize}} className="board">
                {board && board.map((rowSymbols, index) =>
                    <Row key={index} x={index + 1} rowSymbols={rowSymbols} player1={player1} player2={player2}
                         turnTakenHandler={turnTakenHandler}/>
                )}
            </div>
        );
    }
}