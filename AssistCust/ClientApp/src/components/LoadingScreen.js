import React from 'react';
import Loader from 'react-loader-spinner'

export class LoadingScreen extends React.Component {
    render() {
        return (
            <>
                <div style={{
                    position: 'absolute', left: '50%', top: '50%',
                    transform: 'translate(-50%, -50%)',
                    width: '100%',
                    height: '100%',
                    backgroundColor: '#555',
                    opacity: 0.5,
                    zIndex: 99998
                }}>
                </div>
                <div style={{
                    position: 'absolute', left: '50%', top: '50%',
                    transform: 'translate(-50%, -50%)',
                    zIndex: 99999
                }}>
                    <Loader
                        type="Oval"
                        color="#0044ff"
                        height={100}
                        width={100}
                        timeout={10000}
                    />
                </div>
            </>
        );
    }
}