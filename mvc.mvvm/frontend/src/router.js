import React from 'react';
import { Route, BrowserRouter, Switch, Redirect } from 'react-router-dom';
import Home from './pages/Home';

export default function Router() {
  return (
    <BrowserRouter>
      <Switch>
        <Redirect exact from="/" to="/home" />
        <Route
          path="/home"
          component={ Home }
        />
      </Switch>
    </BrowserRouter>
  );
}
