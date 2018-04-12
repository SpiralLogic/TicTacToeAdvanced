class Row extends React.Component {
    render() {
        const x = this.props.x;
        const coords = this.props.coords;
        const updateFunction = this.props.updateFunction;
        return (
            <div className="row">
                {coords.map((entity, index) =>
                    <Coordinate key={index} x={x} y={index + 1} entity={entity} updateFunction={updateFunction}/>
                )}
            </div>
        )
    }
}