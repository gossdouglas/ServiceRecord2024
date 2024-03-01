import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export default function Content() {

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