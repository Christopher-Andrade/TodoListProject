class CityDropDown extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        console.log("called");
        return (
            <div className="form-group">
                <label htmlFor="sel1" className="input-sm" >Select City</label>
                <select className="form-control input-sm" id="sel1">
                    <option key="0" id="0">All</option>
                    {
                        this.props.cities.map(function (city) {
                            return <option key={city.id} id={ city.id }>{city.name}</option>;
                        })
                    }
                    </select>
            </div>
        );
    }
}

//GetCitiesByProvince

class ProvinceDropdown extends React.Component {
    constructor(props) {
        super(props);
       // this.ProvinceDropdown = this.ProvinceDropdown.bind(this);
    }
    change(event) {

       

        var self = this;
        this.setState({ selectedProvince: event.target.value });
       // console.log("state updated");
        //console.log(event.target.value);
        this.props.handler("test");
        var provId = event.target.value;
        $.getJSON("https://localhost:44370/Region/GetCitiesByProvince?provinceId=" + provId)
            .done(function (response) {
               // self.setState({ cities: response });
                this.props.handler(response);
            })
            .fail(function () {
                console.log("error");
            });
        console.log(JSON.stringify(this.state));
    }

    render() {
        return (
            <div className="form-group">
                <label htmlFor="sel2" className="input-sm">Select Province</label>
                
                <select className="form-control input-sm" id="sel2" onChange={this.change.bind(this)}>
                    <option key="0" value="0">All</option>
                    {
                        this.props.provinces.map(function(province) {
                            return <option key={province.Id} value={province.id} >{province.name}</option>;
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
            provinces: [],
            selectedProvince: 0
        };
        this.handleProvinceSelect = this.handleProvinceSelect.bind(this);
    }

    handleProvinceSelect(e) {
        console.log("called2");

        this.setState({ cities: e });
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

        //$.getJSON("https://localhost:44370/Region/GetAllCities")
        //    .done(function(response) {
        //        self.setState({ cities: response });
        //    })
        //    .fail(function() {
        //        console.log("error");
        //    });

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
        //<div className="form-group">
        //    <button type="submit" className="btn btn-default btn-sm">Search</button>
        //</div>
        return (
            <div className="container">
                <div className="panel panel-default">
                    <div className="panel-heading">Filter events by location</div>
                    <div className="panel-body">
                        <div className="form-inline" role="form">
                            <ProvinceDropdown provinces={this.state.provinces} handler={this.handleProvinceSelect.bind(this)}/>
                            <CityDropDown cities={this.state.cities} />
                           
                        </div>
                    </div>
                    <hr/>
                    <div className="text-center"><label>Event Listing</label>
                    </div>
                    <div className="panel-body">
                        <EventListing events={this.state.events}/>
                    </div>
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
                    <span className="glyphicon glyphicon-hand-right"></span>
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