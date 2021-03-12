import React, { Component } from 'react';

export class Developer extends React.Component {
  
  constructor(props) {
    super(props);
      this.state = { developers: [], loading: true, token:'' };
  }

    async componentDidMount() {
        //var t = await fetch('https://localhost:44387/api/v2/GetToken', {
        //    method: 'GET',
        //}).then(res => res.json())
        //    .then((data) => { this.setState({ token: data }) })
        //    .catch(console.log)

        await fetch('https://localhost:44387/api/v1/developers', {
            method: 'Get',
            headers: {
                'Content/Type': 'application/json',
                //'Authentication': 'Bearer ' + this.token
            },
        })  .then(res => res.json())
            .then((data) => {
                this.setState({ developers: data })
        })
            .catch(console.log)
    }

    render(developers) {
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
                {this.state.developers.map(dev =>
                    <tr key={dev.id}>
                        <td>{dev.name}</td>
                        <td>{dev.cpf}</td>
                        <td>{dev.created}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
  }
}