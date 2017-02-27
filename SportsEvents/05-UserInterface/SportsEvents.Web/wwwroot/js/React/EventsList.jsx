class CityDropDown extends React.Component {
    render() {
        return (
            <div className="form-group input-sm">
                <label htmlFor="sel1" className="input-sm" >Select City</label>
                <select className="form-control input-sm" id="sel1">
                    {
                        this.props.cities.map(function (city) {
                            return <option key={city.id}>{city.name}</option>;
                        })
                    }
                    </select>
            </div>
        );
    }
}

class ProvinceDropdown extends React.Component {
    render() {
        return (
            <div className="form-group input-sm">
                <label htmlFor="sel2" className="input-sm">Select Province</label>
                <select className="form-control input-sm" id="sel2">
                    {
                        this.props.provinces.map(function(province) {
                            return <option key={province.Id}>{province.name}</option>;
                        })
                    }
                </select>
            </div>
        );
    }
}

class EventSelector extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            events: [],
            cities: [],
            provinces: []
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
            .done(function(response) {
                self.setState({ cities: response });
            })
            .fail(function() {
                console.log("error");
            });

        $.getJSON("https://localhost:44370/Region/GetAllProvinces")
            .done(function(response) {
                self.setState({ provinces: response });
            })
            .fail(function() {
                console.log("error");
            });
    }

    componentWillUnmount() {

    }

    render() {
        return (
            <div className="panel panel-default">
                <div className="panel-heading">Filter events by location</div>
                <div className="panel-body">
                    <div className="form-inline" role="form">
                        <ProvinceDropdown provinces={this.state.provinces}/>
                        <CityDropDown cities={this.state.cities}/>
                        <button type="submit" className="btn btn-default btn-xs">Search</button>
                    </div>
                </div>

                <label>Event Listing</label>
                <div className="panel-body">
                    <EventListing events={this.state.events}/>
                </div>
            </div>
        );
    }
}


class EventListing extends React.Component {
    render() {
        var events = this.props.events;
        return (
            <div className="eventList">
                {
                    this.props.events.map(function(event) {
                        return <EventItem key={event.Id} event={event}/>;
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
            <div className="media">
                <div className="media-left">
                    <img src="/images/dot-blue.png" className="media-object" style={{ width: "50px" }} />
                </div>
                <div className="media-body" key={event.Id}>
                    <h4 className="media-heading"> {event.name}</h4>
                    <p> {event.description}</p>
                </div>
            </div>
        );
    }
}

ReactDOM.render(
    <EventSelector />,
    document.getElementById('content')
);