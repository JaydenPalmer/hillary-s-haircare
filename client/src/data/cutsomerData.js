const apiURL = "/api/customers";

export const getCustomers = () => {
  return fetch(apiURL).then((res) => res.json());
};
