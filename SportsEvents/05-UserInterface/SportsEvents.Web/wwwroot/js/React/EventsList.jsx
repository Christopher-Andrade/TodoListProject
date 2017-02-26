//function fetchEvents() {
//    var value = $.ajax({
//        url: 'https://localhost:44370/Event/GetAll',
//        async: false
//    }).responseText;
//    return value;
//};

class EventSelector extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            events: []
        };
    }


    componentDidMount() {
        var self = this;
        ////Get event list
        $.getJSON("https://localhost:44370/Event/GetAll")
            .done(function (response) {
               // console.log(response);
              //  JSON.stringify(response[0]);
                self.setState({ events: response });
              //  console.log(JSON.stringify(this.state));
            })
            .fail(function() {
                console.log("error");
            })
            //.always(function() {
            //    console.log("complete");
            //});
    }

    componentWillUnmount() {

    }

    render() {
        return (
            //<form method="post" action="Event/Search">
         
            <div className="eventList">
                <h4>
                    <p className="text-center">
                        Filter events by location
                    </p>
                </h4>
                <div className="form-group">
                    <label>Province:</label>
                //Ddl
                </div>

                <div className="form-group">
                    <label>City:</label>
                //Ddl
                </div>
                <button type="submit" className="btn btn-default">Search</button>
                   <EventListing events={this.state.events}/>
            </div>
            //</form>
        );
    }
}

class EventListing extends React.Component {
    render() {
        var events = this.props.events;
        return (
            <div className="eventList">
                <h5>Events:</h5>

                //{JSON.stringify(events).forEach((event) => {
                //    console.log(event);
                //});
                    </div>
        );
    }
}

class EventItem extends React.Component {
    render() {
        var event = this.props.event;
        return (
            <div className="eventItem">
                <ul>
                    <li>{event.name}</li>
                    <li>{event.description}</li>
                  
                </ul>

            </div>
        );
    }
}

ReactDOM.render(
    <EventSelector />,
    document.getElementById('content')
);