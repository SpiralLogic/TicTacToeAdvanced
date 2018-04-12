class Coordinate extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
        this.updateFunction = this.props.updateFunction;
    }

    render() {
        const game = this.props.game;
        const entity = this.props.entity;
        const x = this.props.x;
        const y = this.props.y;
        const playerClass = entity === game.player1 ? ' p1' : entity === game.player2 ? ' p2' : '';
        return (
            <div onClick={this.handleClick} className={"coordinate" + playerClass} x={x} y={y}>{entity}</div>
        )
    }

    handleClick() {
        this.updateFunction(this.props.x, this.props.y)
    }
}