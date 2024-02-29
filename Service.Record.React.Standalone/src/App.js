import logo from './logo.svg';
import './App.css';


import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import {CORE_CONCEPTS} from './data.js';
import {RandomDescription} from './components/RandomDescription.jsx';
import ImageOne from './components/ImageOne.jsx';
import Navigation from './components/Navigation.jsx';


function CoreConcept(props) {
  return (
    <li>      
      <h3>{props.title}</h3>
      <p>{props.description}</p>
      <img src={props.image} alt={props.title} />
    </li>
  );
}



function Content() {

  return (
    <div style={{backgroundColor: "blue", color: "white"}}>
      <Container>
      <Row>
        <Col>1 of 1</Col>
      </Row>
    </Container>

    </div>   
  );
}

function App() {
  return (
    <div className="container-grid">
      <div className="header" >
        <Navigation />
      </div>

      <div className="main">
          main
          <RandomDescription/>
          <ImageOne/>
          <section id="core-concepts">
          <h2>Core Concepts</h2>
          <ul>
            <CoreConcept
              title="Components"
              description="The core UI building block."
              image={ImageOne}
            />
            <CoreConcept {...CORE_CONCEPTS[1]}/>
          </ul>
        </section>
      </div>

      <div className="footer">
      footer
      </div>
      
    </div>
  );
}

export default App;
