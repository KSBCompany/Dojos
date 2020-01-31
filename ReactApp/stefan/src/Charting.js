import React from 'react';
import './App.css';

import Highcharts from 'highcharts';
import HighchartsReact from 'highcharts-react-official'

const options = {
  series: [
    {
      name: 'Profit',
      data: [1, 2, 1, 4, 3, 6]
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
