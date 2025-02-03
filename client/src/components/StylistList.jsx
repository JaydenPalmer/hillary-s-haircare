import { useEffect, useState } from "react";
import { getStylists } from "../data/stylistData";
import { Table } from "reactstrap";

export default function StylistList() {
  const [stylists, setStylists] = useState([]);

  useEffect(() => {
    getStylists().then(setStylists);
  }, []);

  const handleDeactivateStylist = (e) => {
    console.log(e);
  };

  return (
    <div className="container">
      <Table bordered>
        <thead>
          <tr>
            <th>Stylist</th>
            <th>Active?</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {stylists?.map((s) => (
            <tr key={s.id}>
              <td>{s.name}</td>
              <td
                style={{
                  color: s.isActive ? "#155724" : "#721c24",
                  fontWeight: "bold",
                }}
              >
                {s.isActive ? "YEP" : "NOPE"}
              </td>
              <td>
                {s.isActive ? (
                  <button
                    className="btn btn-warning"
                    value={s.id}
                    onClick={(event) =>
                      handleDeactivateStylist(event.target.value)
                    }
                  >
                    Deactivate
                  </button>
                ) : (
                  ""
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
}
