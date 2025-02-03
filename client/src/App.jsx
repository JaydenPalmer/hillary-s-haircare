import "./App.css";
import "bootstrap/dist/css/bootstrap.css";
import { Nav, Navbar, NavbarBrand, NavItem, NavLink } from "reactstrap";
import { Outlet } from "react-router-dom";

function App() {
  return (
    <>
      <Navbar color="info" expand="md">
        <div className="d-flex gap-3">
          <NavbarBrand href="/">Hillary's Haircare</NavbarBrand>
          <Nav>
            <NavItem>
              <NavLink href="/">Appointments</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/stylists">Stylists</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/customers">Customers</NavLink>
            </NavItem>
          </Nav>
        </div>
      </Navbar>
      <Outlet />
    </>
  );
}

export default App;
