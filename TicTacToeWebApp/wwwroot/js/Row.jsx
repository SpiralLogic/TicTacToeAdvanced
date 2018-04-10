class Row extends React.Component {
    render() {
        return (
            <div className="row">
                {[...Array(this.props.size)].map((value, index) =>
                    <Coordinate key={index} x={this.props.x + 1} y={index + 1}/>
                )}
            </div>
        )
    }
}