import React from "react";
import "./App.css";
import Header from "./components/header/header.component";
import Search from "./pages/search/search.component";

const App = () => {
  return (
    <div className="App">
      <Header title="SEO Rank Checker" />
      <Search />
    </div>
  );
};

export default App;
