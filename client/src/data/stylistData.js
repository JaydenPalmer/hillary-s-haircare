const apiURL = "/api/stylists";

export const getStylists = () => {
  return fetch(apiURL).then((res) => res.json());
};
