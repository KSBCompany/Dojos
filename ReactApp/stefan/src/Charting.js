import React from 'react';
import './App.css';

import Highcharts from 'highcharts';
import HighchartsReact from 'highcharts-react-official'

const options = {
  series: [
    {
      name: 'Curve1',
      data: [500, 490, 450, 420, 350, 200]
    },
    {
      name: 'Curve2',
      data: [600, 550, 490, 400, 200, 50]
    }
  ]
};

function Charting() {

  return (
    <div>
    <HighchartsReact highcharts={Highcharts} options={options} />
    </div>
  );
}

export default Charting;
