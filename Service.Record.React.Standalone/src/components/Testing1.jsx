<div className="container-grid">
      <div className="header" >
        <Navigation />
      </div>

      <div className="main">
          main
          {/* <RandomDescription/>
          <ImageOne/>
          <section id="core-concepts">
          <h2>Core Concepts</h2>
          <ul>
            <CoreConcept           
              title="Components" description="The core UI building block." image={ImageOne}
            />
            yo-bitches
            <CoreConcept {...CORE_CONCEPTS[1]}/>
          </ul>
        </section> */}
        <section id="examples">
          <h2>Examples</h2>
          <menu>
            <TabButton onSelect={() => handleSelect('components')}>Components</TabButton>
            <TabButton onSelect={() => handleSelect('jsx')}>JSX</TabButton>
            <TabButton onSelect={() => handleSelect('props')}>Props</TabButton>
            <TabButton onSelect={() => handleSelect('state')}>State</TabButton>
          </menu>
          {selectedTopic}
        </section>
      </div>

      <div className="footer">
      footer
      </div>
      
    </div>