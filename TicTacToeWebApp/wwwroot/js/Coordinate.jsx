class Coordinate extends React.Component {
    constructor(props) {
    super(props);
    this.handleClick = this.handleClick.bind(this);
    this.state = {className: 'coordinate'}
}

render() {
    return (
        <div onClick={this.handleClick} className={this.state.className} >{this.props.x + "," + this.props.y}</div>
    )
}

handleClick() {
    this.setState({className: 'coordinate clicked'});
}
}