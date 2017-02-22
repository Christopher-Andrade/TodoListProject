class EventSelector extends React.Component {
    render() {
        return (
            <form method="post" action="Event/Search">
                <div className="eventList">
                    <p className="text-center">
                        <h4>Filter events by location</h4>
                    </p>
                    <div className="form-group">
                        <label>Province:</label>
                    //Ddl
                    </div>

                    <div className="form-group">
                        <label>City:</label>
                    //Ddl
                    </div>

                    <button type="submit" class="btn btn-default">Search</button>
                </div>
            </form>
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

ReactDOM.render(
    <EventSelector />,
    document.getElementById('content')
);