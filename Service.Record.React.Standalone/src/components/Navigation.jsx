import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';

export default function Navigation() {

    return (
      <div>
        <container class="navigation-bar">
          <Row>
            <Col sm={8}>
              <Navbar expand="lg" className="bg-body-tertiary" sticky="top">
                {/* <Container> */}
                <Navbar.Brand href="#home">Field Service Record</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                  <Nav className="me-auto">
                    <Nav.Link href="#home">Current Daily Reports</Nav.Link>
                    <Nav.Link href="#home">All Daily Reports</Nav.Link>
                    <Nav.Link href="#home">Create New Daily Report</Nav.Link>
                    <Nav.Link href="#home">Active Daily Report</Nav.Link>
                    <NavDropdown title="Admin Tasks" id="basic-nav-dropdown">
                      <NavDropdown.Item href="#action/3.1">Customers</NavDropdown.Item>
                      <NavDropdown.Item href="#action/3.2">Jobs</NavDropdown.Item>
                      <NavDropdown.Item href="#action/3.3">Sub-job Types</NavDropdown.Item>
                      <NavDropdown.Item href="#action/3.3">Resource Types</NavDropdown.Item>
                      <NavDropdown.Item href="#action/3.3">Users</NavDropdown.Item>
                    </NavDropdown>
                  </Nav>
                </Navbar.Collapse>
                {/* </Container> */}
              </Navbar>
            </Col>
            <Col sm={4}>
              <Navbar expand="lg" className="bg-body-tertiary" sticky="top">
                <Navbar.Brand href="#home">Welcome, Tony</Navbar.Brand>
                <Nav.Link href="#home">Log Off</Nav.Link>
              </Navbar>
            </Col>
          </Row>
        </container>
      </div>
    );
  }