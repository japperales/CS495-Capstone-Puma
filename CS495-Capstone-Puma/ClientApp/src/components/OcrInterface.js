import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'
import Boundingbox from 'react-bounding-box';
import ImageUploader from 'react-images-upload';
import {TokenContext} from "../Contexts/TokenContext";

let state ={
    hoverIndex: 0,
    clickedIndex: 0,
    picture: null,
    boundingHeight: 0,
    boundingWidth: 0
};

const params = {
    image: "https://woodworkersbelfast.com/wp-content/uploads/2018/06/placeholder.png",
    boxes: [
        // coord(0,0) = top left corner of image
        //[x, y, width, height]
        
         {coord: [0, 0, 250, 250], label: ""},
         {coord: [300, 0, 250, 250], label: "A"},
         {coord: [700, 0, 300, 25], label: "B"},
         {coord: [1100, 0, 25, 300], label: "C"}
    ],
    options: {
        colors: {
            normal: 'rgba(255,225,255,1)',
            selected: 'rgba(0,225,204,1)',
            unselected: 'rgba(100,100,100,1)'
        },
        showLabels: true
    }
};

export class OcrInterface extends React.Component{
    
    static contextType = TokenContext;
    
    componentDidMount(){
        console.log("component did mount");
    }

    componentWillUnmount() {
        state = this.state;
    }
    
    constructor(props){
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
        this.updateHoverIndex = this.updateHoverIndex.bind(this);
        this.updateClickedIndex = this.updateClickedIndex.bind(this);
        this.onDrop = this.onDrop.bind(this);
        this.sendImage = this.sendImage.bind(this);
        this.sendBoxWithImage = this.sendBoxWithImage.bind(this);
    }
    
    updateHoverIndex(num){
        this.setState({hoverIndex: num});
        console.log("we have called update hover index")
    }
    
    updateClickedIndex(e){
        e.preventDefault();
        const currentHover = this.state.hoverIndex;
        this.setState({clickedIndex: currentHover});
        console.log("WE HAVE CALLED UPDATE CLICKED INDEX");
        if(this.state.hoverIndex === -1 || this.state.hoverIndex === ""){
            this.setState({clickedIndex: ""})
        }
    }
    
    onDrop(file, picture) {
        this.setState({
            picture: picture
        });
        console.log("Picture stuff is: " + JSON.stringify(picture));
        params.image = picture;
        console.log(typeof picture);
        console.log("We have called the on drop function!");
    }
    
    async handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        await this.setState({
            [name]: value
        });
    }

    sendImage(event){
            event.preventDefault();
            console.log(this.context.Jwt);
            console.log("IMAGE STUFF RIGHT BEFORE WE SEND IT IS: " + JSON.stringify(params.image));
            if (this.context !== null) {
                fetch('api/Puma/PostImage', {
                    method: 'POST',
                    headers: {
                        'jwt': this.context.Jwt,
                        'Accept': 'application/json',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(params.image[0])
                }).then(response => response.json())
                    .then((data) => {
                        console.log(JSON.stringify(data));
                        params.boxes = data;
                        window.alert("Bounding boxes have been received.")
                    });
            }
        
    }

    sendBoxWithImage(event){
        event.preventDefault();
        console.log(this.context.Jwt);
        console.log("IMAGE STUFF RIGHT BEFORE WE SEND IT IS: " + JSON.stringify(params.image));
        if (this.context !== null) {
            fetch('api/Puma/PostImageWithBox', {
                method: 'POST',
                headers: {
                    'jwt': this.context.Jwt,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    image: params.image[0],
                    box: params.boxes[this.state.clickedIndex]
                })
            }).then(response => response.json())
                .then((data) => {
                    console.log(JSON.stringify(data));
                    if (data !== null) {
                        for(let asset of data) {
                            const newAsset = {
                                assetId: data.id,
                                assetCode: data.value.AssetCode,
                                symbol: data.value.Symbol,
                                issue: data.value.Issue,
                                issuer: data.value.Issuer,
                                units: this.state.inputUnits
                            };
                            const copyOfCurrentPortfolio = [...this.props.currentPortfolio];
                            copyOfCurrentPortfolio.push(newAsset);
                            this.props.assetCallback(copyOfCurrentPortfolio);
                        }
                        
                    }
                });
        }

    }
    
    
    render(){
        return(
            <div className="container">
                <h3>Current box selection is: {params.boxes[this.state.clickedIndex].label}</h3>
                <ImageUploader
                    withIcon={true}
                    buttonText='Choose Image (.png)'
                    onChange={this.onDrop}
                    imgExtension={['.png']}
                    maxFileSize={5242880}
                    withLabel={false}
                />
                <div className="row">
                    <div className="col s6" >
                        <br />
                        <div onClick={this.updateClickedIndex} style={{textAlign: "center"}}>
                                <div>
                                <Boundingbox
                                         image={params.image}
                                         boxes={params.boxes}
                                         options={params.options}
                                         onSelected={this.updateHoverIndex}
                                         style={{textAlign: "center"}}
                                         
                                />
                                </div>
                        </div>
                    </div>
                        
            </div>
                <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.sendImage}>Submit Image</a>
                <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.sendBoxWithImage}>Submit Selected Box</a>
            </div>
            
        );
    }

}