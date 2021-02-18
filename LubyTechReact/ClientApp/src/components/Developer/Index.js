import React, { Component } from 'react';

export class Developer extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { developers: [], loading: true };
  }

    componentDidMount() {
        await fetch('https://localhost:44387/api/v1/developers' ,{
            method: 'Get',
            headers: {
                'Content/Type': 'application/json',
                'Authentication': 'Bearer ' 
            },

            })
            .then(res => res.json())
            .then((data) => {
                this.setState({ developers: data })
            })
            .catch(console.log)
    }

    static render(developers) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>CPF</th>
            <th>Created</th>
          </tr>
        </thead>
        <tbody>
          {developers.map(dev =>
              <tr key={dev.Id}>
                  <td>{dev.Name}</td>
                  <td>{dev.CPF}</td>
                  <td>{dev.Created}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
}
