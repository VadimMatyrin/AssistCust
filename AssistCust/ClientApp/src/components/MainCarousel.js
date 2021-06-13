import React, { Component } from 'react';
import "react-responsive-carousel/lib/styles/carousel.min.css";
import slide1 from './assets/slide4.jpg'
import slide2 from './assets/slide5.jpg'
import slide3 from './assets/slide6.jpg'
import { Carousel } from 'react-responsive-carousel';
 
export class MainCarousel extends Component {
    render() {
        return (
            <Carousel>
                <div>
                    <img src={slide3} alt="slide3" />
                </div>
                <div>
                    <img src={slide1} alt="slide1" />
                </div>
                <div>
                    <img src={slide2} alt="slide2" />
                </div>
            </Carousel>
        );
    }
}