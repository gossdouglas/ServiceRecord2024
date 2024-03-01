import './App.css';
import { useState } from 'react';

import { EXAMPLES } from './assets/react-course-assets/data/data.js';
import { CORE_CONCEPTS } from './assets/react-course-assets/data/data.js';


import { RandomDescription } from './components/RandomDescription.jsx';
import ImageOne from './components/ImageOne.jsx';
import Navigation from './components/Navigation.jsx';
import CoreConcept from './components/CoreConcept.jsx';
import TabButton from './components/TabButton.jsx';

function App() {

  //const [selectedTopic, setSelectedTopic] = useState('Please click a button');
  //const [selectedTopic, setSelectedTopic] = useState('components');//use state is pre-loaded
  const [selectedTopic, setSelectedTopic] = useState();//use state is empty
  console.log("under useState selectedTopic: " + selectedTopic);

  function handleSelect(selectedButton) {
    //console.log("Hello from handleSelect bitches.");
    //console.log(btnClicked + " was clicked.");
    //console.log("Good afternoon bitches. The " + children + " button was pressed.")

    setSelectedTopic(selectedButton);
  }

  console.log('APP COMPONENT EXECUTING');

  var tabContent = <p>Select a topic.</p>;

  if (selectedTopic) {
    tabContent =
      <div id="tab-content">
        <h3>{EXAMPLES[selectedTopic].title}</h3>
        <p>{EXAMPLES[selectedTopic].description}</p>
        <pre>
          <code>{EXAMPLES[selectedTopic].code}</code>
        </pre>
      </div>
  }

  return (
    <div className="container-grid">

      <div className="header" >
        <Navigation />
      </div>

      <div className="main">
        main

        <main>
        <section id="core-concepts">
          <h2>Core Concepts</h2>
          <ul>
            {CORE_CONCEPTS.map((conceptItem) => (
              <CoreConcept key={conceptItem.title} {...conceptItem} />
            ))}
          </ul>
        </section>

        <section id="examples">
          <h2>Examples</h2>
          <menu>
            <TabButton
              isSelected={selectedTopic === 'components'}
              onSelect={() => handleSelect('components')}>
              Components
            </TabButton>

            <TabButton
              isSelected={selectedTopic === 'jsx'}
              onSelect={() => handleSelect('jsx')}>
              JSX
            </TabButton>

            <TabButton
              isSelected={selectedTopic === 'props'}
              onSelect={() => handleSelect('props')}>
              Props
            </TabButton>

            <TabButton
              isSelected={selectedTopic === 'state'}
              onSelect={() => handleSelect('state')}>
              State</TabButton>
          </menu>
          {/* {selectedTopic} */}
          {tabContent}
        </section>
        </main>

        
      </div>

      <div className="footer">
        footer
      </div>

    </div>
  );
}

export default App;
