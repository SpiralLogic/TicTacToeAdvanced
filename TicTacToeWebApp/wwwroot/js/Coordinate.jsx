class Coordinate extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
        this.updateFunction = this.props.updateFunction;
        this.state = {className: 'coordinate'}
    }

    render() {
        const entity = this.props.entity;
        const x = this.props.x;
        const y = this.props.y;
        return (
            <div onClick={this.handleClick} className={this.state.className} x={x} y={y}>{entity}</div>
        )
    }

    handleClick() {
        this.setState({className: 'coordinate clicked'});
        this.updateFunction(this.props.x, this.props.y)
    }
}