import axios, { AxiosResponse } from "axios";

// Url needs to be changed when hosted in the cloud.
const baseUrl = "https://assetnxt.azurewebsites.net";
//const baseUrl = "http://localhost:5000";
axios.defaults.baseURL = `${baseUrl}/api`;

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) =>
    axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) =>
    axios.put(url, body).then(responseBody),
  delete: (url: string) =>
    axios.delete(url).then(responseBody),
};

const Stations = {
  getStations: (): Promise<any> => requests.get("/stations"),
  getStationsByDeviceId: (id: string): Promise<any> => requests.get(`/stations/all/${id}`),
}

const Notification = {
  getNotifications: (): Promise<any> => requests.get("/notifications"),
}

const Routes = {
  getRoutes: (): Promise<any> => requests.get("/routes"),
  getRoutesByDeviceId: (id: string): Promise<any> => requests.get(`/routes/device/${id}`),
  applyRoute: (id: string, route: any): Promise<any> => requests.put(`/routes/${id}`, route),
  createRoute: (route: any): Promise<any> => requests.post("/routes", route),
  updateRoute: (id: string, route: any): Promise<any> => requests.put(`/routes/${id}`, route),
  deleteRoute: (id: string): Promise<any> => requests.delete(`/routes/${id}`),
  editRoute: (id: string, route: any): Promise<any> => requests.put(`/constraints/${id}`, route),
}

const Telemetric = {
  getConstraints: (): Promise<any> => requests.get("/constraints"),
  getConstrainsByDeviceId: (id: string): Promise<any> => requests.get(`/constraints/device/${id}`),
  applyConstraints: (sla: any): Promise<any> => requests.put("/constraints", sla),
  createConstraints: (sla: any): Promise<any> => requests.post("/constraints", sla),
  deleteConstraints: (id: string): Promise<any> => requests.delete(`/constraints/${id}`),
  editConstraints: (id: string, sla: any): Promise<any> => requests.put(`/constraints/${id}`, sla)
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
  Notification,
  Stations,
  Routes,
  Telemetric, 
  baseUrl
};