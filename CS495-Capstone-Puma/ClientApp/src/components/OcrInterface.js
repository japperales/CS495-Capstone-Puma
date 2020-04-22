import React from 'react'
import { post } from 'axios';
import  './css/PersonalInput.css'
import M from 'materialize-css'
import Boundingbox from 'react-bounding-box';
import { Document, Page } from 'react-pdf';
import ImageUploader from 'react-images-upload';
import {TokenContext} from "../Contexts/TokenContext";

let state ={
    hoverIndex: 0,
    clickedIndex: 0,
    pictureData: null,
    file: null,
    boundingHeight: 0,
    boundingWidth: 0
};

const params = {
    image: "https://woodworkersbelfast.com/wp-content/uploads/2018/06/placeholder.png",
    boxes: [
        // coord(0,0) = top left corner of image
        //[x, y, width, height]

        {coord: [0, 0, 1, 1], label: ""}
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

export class OcrInterface extends React.Component {
    constructor(props) {
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
        this.updateHoverIndex = this.updateHoverIndex.bind(this);
        this.updateClickedIndex = this.updateClickedIndex.bind(this);
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

    async handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        await this.setState({
            [name]: value
        });
    }

    async submit(e) {
        e.preventDefault();

        const url = `/api/Puma/PostImage`;
        const formData = new FormData();
        formData.append('body', this.state.file);
        const config = {
            headers: {
                'content-type': 'multipart/form-data',
            },
        };
        post(url, formData, config)
            .then(response => {
                console.log(JSON.stringify(response.data));
                params.boxes = response.data["BoundingBoxIdentifiers"];
                window.alert("Bounding boxes have been received.")
            });
    }

    setFile(e) {
        this.setState({ file: e.target.files[0] });
        params.image = URL.createObjectURL(e.target.files[0]);
    }

    sendBoxWithImage(event){
        event.preventDefault();
        console.log("IMAGE STUFF RIGHT BEFORE WE SEND IT IS: " + JSON.stringify(params.image));
        if (this.context !== null) {
            fetch('api/Puma/PostImageWithBox', {
                method: 'POST',
                headers: {
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

    render() {
        return (
            <div className="container">
                <form onSubmit={e => this.submit(e)}>
                    <h1>File Upload</h1>
                    <input type="file" onChange={e => this.setFile(e)} />
                    <button type="submit">Upload</button>
                    <p>After Upload, please wait while Textract analyzes your document.
                        You will be prompted to provide input shortly.</p>
                </form>

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
                <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.sendBoxWithImage}>Submit Selected Box</a>
            </div>
            
        );
    }
}