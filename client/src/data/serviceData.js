const apiURL = "/api/services";

export const getServices = () => {
  return fetch(apiURL).then((res) => res.json());
};
