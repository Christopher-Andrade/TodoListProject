class EventSelector extends React.Component {
    render() {
        return (
            <div className="eventList">
                <h2>Filter events by location</h2>
                <div className="row">
                    <div className="col-md-2">Province:</div>
                    //Ddl
                </div>

                <div className="row">
                    <div className="col-md-2">City:</div>
                //Ddl
                </div>
            </div>
        )
    }
}

class EventListing extends React.Component {
    render() {
        return (
            <div className="eventList">
                <h1>Events:</h1>

            </div>
        )
    }
}

class EventItem extends React.Component {
    render() {
        return (
            <div className="eventItem">
                <ul>
                    <li>Event 1</li>
                </ul>

            </div>
        )
    }
}