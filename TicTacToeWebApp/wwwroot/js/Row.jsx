class Row extends React.Component {
    render() {
        const {x, rowSymbols, player1, player2, turnTakenHandler} = this.props;
        return (
            <div className="row">
                {rowSymbols.map((symbol, index) =>
                    <Coordinate key={index} x={x} y={index + 1} symbol={symbol} turnTakenHandler={turnTakenHandler}
                                player1={player1} player2={player2}/>
                )}
            </div>
        )
    }
}