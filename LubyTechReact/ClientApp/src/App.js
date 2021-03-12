import React, { Component } from 'react';
import { Route } from 'react-router';

//Components Pages
import { Layout } from './components/_Layout/Layout';
import { Home } from './components/Home/Index';
import { Project } from './components/Project/Index';
import { Ranking } from './components/Ranking/Index';
import { Developer } from './components/Developer/Index';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/project' component={Project} />
        <Route path='/developer' component={Developer} />
        <Route path='/ranking' component={Ranking} />
      </Layout>
    );
  }
}
