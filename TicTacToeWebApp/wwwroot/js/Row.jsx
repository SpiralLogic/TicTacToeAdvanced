class Row extends React.Component {
    render() {
        const x = this.props.x;
        const rowEntities = this.props.rowEntities;
        const game = this.props.game;
        const updateFunction = this.props.updateFunction;
        return (
            <div className="row">
                {rowEntities.map((entity, index) =>
                    <Coordinate key={index} x={x} y={index + 1} entity={entity} updateFunction={updateFunction} game={game}/>
                )}
            </div>
        )
    }
}