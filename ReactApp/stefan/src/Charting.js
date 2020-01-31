import React from 'react';
import './App.css';

import Highcharts from 'highcharts';
import HighchartsReact from 'react-highcharts'



function Charting() {

  const options = {
    chart: {
      type: 'spline'
    },
    title: {
      text: 'My chart'
    },
    series: [
      {
        data: [1, 2, 1, 4, 3, 6]
      }
    ]
  };

  return (
    <div>
      <HighchartsReact highcharts={Highcharts} options={options} />
    </div>
  );
}

export default Charting;
