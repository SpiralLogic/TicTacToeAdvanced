class Board extends React.Component {
    render() {
        return (
            <div className="board">
                {[...Array(this.props.size)].map((value, index) =>
                    <Row key={index} x={index} size={this.props.size}/>
                )}
            </div>
        );
    }
}

const size = 5;
ReactDOM.render(
    <Board size={size}/>,
    document.getElementById('content')
);
