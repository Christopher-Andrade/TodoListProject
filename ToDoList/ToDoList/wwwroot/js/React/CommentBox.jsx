class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">
                <h3>Comments for this event:</h3>
                <CommentRow comment="Test Comment" username="Sipho" date="12 dec 2016" />
            </div> 
            )
    }
}

var getTimeDifference = function (dateTime) {

    var currentDate = new Date().toLocaleString();
    var diff = (currentDate - dateTime) / 1000;
    return diff + ' seconds ago';
}


class CommentRow extends React.Component {
    render() {
        return (
            <div className="grid">
                <div className="row">
                    <span><blockquote>
                        <p>{this.props.comment}</p>
                        <footer><strong>{this.props.username}</strong> @ {this.props.date}</footer>
                    </blockquote></span>
                </div>
            </div>
            )
    }
}

ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);