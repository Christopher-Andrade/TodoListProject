//function fetchEvents() {
//    var value = $.ajax({
//        url: 'https://localhost:44370/Event/GetAll',
//        async: false
//    }).responseText;
//    return value;
//};

class CityDropDown extends React.Component {
    render() {
        return (
            <div className="dropdown">
                <button className="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Cities
                    <span className="caret"></span></button>
                <ul className="dropdown-menu">

                    {
                        this.props.cities.map(function (city) {
                            return <li><a href="#">{city.name}</a></li>
                        })
                    }
                  
                </ul>


            </div>
        );

    }
}

class ProvinceDropdown extends React.Component {
    render() {
        return (
            <div className="dropdown">
                <button className="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Cities
                    <span className="caret"></span></button>
                <ul className="dropdown-menu">

                    {
                        this.props.provinces.map(function (province) {
                            return <li><a href="#">{province.name}</a></li>
                        })
                    }

                </ul>


            </div>
        );
}

class EventSelector extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            events: [],
            cities: [],
            provinces:[]
        };
    }


    componentDidMount() {
        var self = this;
        //Get event list
        $.getJSON("https://localhost:44370/Event/GetAll")
            .done(function(response) {
                self.setState({ events: response });
            })
            .fail(function() {
                console.log("error");
            });

        $.getJSON("https://localhost:44370/Region/GetAllCities")
            .done(function (response) {
                self.setState({ cities: response });
            })
            .fail(function () {
                console.log("error");
            });

        $.getJSON("https://localhost:44370/Region/GetAllProvinces")
            .done(function (response) {
                self.setState({ provinces: response });
            })
            .fail(function () {
                console.log("error");
            });
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
                    <ProvinceDropDown provinces={this.state.provinces} />
                </div>

                <div className="form-group">
                    <label>City:</label>
                <CityDropDown cities={this.state.cities}/>
                </div>
                <button type="submit" className="btn btn-default">Search</button>
                   <EventListing events={this.state.events}/>
            </div>
            
        );
    }
}

class EventListing extends React.Component {
    render() {
        var events = this.props.events;
        return (
            <div className="eventList">
                <h5>Events:</h5>

                {
                    this.props.events.map(function(event) {
                        return <EventItem event={event}/>
                    })
                }
                    </div>
        );
    }
}







class EventItem extends React.Component {
    render() {
        var event = this.props.event;
        return (
            <div className="eventItem">
                    {event.name}
                    {event.description}
            </div>
        );
    }
}

ReactDOM.render(
    <EventSelector />,
    document.getElementById('content')
);