class Coordinate extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
        this.turnTakenHandler = this.props.turnTakenHandler;
    }

    render() {
        const {x, y, symbol, player1, player2} = this.props;
        const playerClass = symbol === player1 ? ' p1' : symbol === player2 ? ' p2' : '';
        return (
            <div onClick={this.handleClick} className={"coordinate" + playerClass} x={x} y={y}>{symbol}</div>
        )
    }

    handleClick() {
        this.turnTakenHandler(this.props.x, this.props.y)
    }
}