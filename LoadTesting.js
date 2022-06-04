import http from 'k6/http';
import { check, sleep } from 'k6';

//specify the when the request will start along with how many users/requests
export let options = {
    stages: [
        { duration: '15s', target: 100 },
        { duration: '30s', target: 100 },
        { duration: '15s', target: 0 }
    ],
};

export default function () { //this is the main function
    //determine the url request to test it with k6 load testing
    let res = http.get('https://localhost:44323/api/Search/geteventsbylocation?location=Tilburg');
    check(res, { 'status was 200': r => r.status == 200 });
    sleep(1);//waiting one second
}